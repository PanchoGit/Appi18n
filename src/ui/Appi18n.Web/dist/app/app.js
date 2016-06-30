var appVue = new Vue({
    el: '#app',
    data: function() {
        return {
            currentViewName: 'home',
            lastRowId:0,
            rowSelected: false,
            noteEditModel: {
                id: 0,
                name: '',
                text: '',
                date: ''
            }
        }
    },
    ready: function () {
        this.showView(this.currentViewName);
        this.getNotes();
        $('.datepicker').datepicker();
    },
    methods: {
        showView: function (name) {
            this.hideView(this.currentViewName);

            $("#" + name).removeClass("app-hide").removeClass("scale2");
            var item = document.getElementById(name);
            item.style.opacity = "0";
            item.style.transform = "scale(2,2)";
            item.style.display = "";

            this.currentViewName = name;
            TweenLite.to(item, 1, { scale: 1, alpha: 1, ease: Expo.easeInOut });
        },
        hideView: function (name) {
            var item = document.getElementById(name);
            TweenLite.to(item, 1, {
                scale: 1.5, alpha: 0, ease: Expo.easeInOut, onComplete: function () {
                    item.style.display = "none";
                }
            });
        },
        startClick:function() {
            this.showView("edit");
        },
        goHomeClick:function() {
            this.showView("home");
        },
        getNotes: function () {
            var self = this;
            $.ajax({
                url: '/api/Note/GetAll',
                success: function (data) {
                    self.setNotesControl(data);
                }
            });
            $("#grid-selection").bootgrid({
                navigation: 0,
                selection: true,
                rowSelect: false,
                multiSelect:false
            }).on("selected.rs.jquery.bootgrid", function (e, rows) {
                $("#grid-selection").bootgrid("deselect", [self.lastRowId]);
                var item;
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i] !== self.lastRowId) {
                        item = rows[i];
                    }
                }
                if (item != null && item.id > 0) {
                    self.rowSelected = true;
                    self.noteEditModel = item;
                    self.lastRowId = item.id;
                }
            }).on("deselected.rs.jquery.bootgrid", function () {
                self.rowSelected = false;
            });
        },
        setNotesControl: function (data) {
            $("#grid-selection").bootgrid("append", data);
        },
        editNote: function () {
            this.showView("edit");
        }
    }
});