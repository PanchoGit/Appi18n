moment.locale("es");
console.log("moment.locale = " + moment.locale());
var locale = window.navigator.userLanguage || window.navigator.language;
console.log("locale = " + locale);

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
            },
            timeZoneOffset: (new Date().getTimezoneOffset() / 60) * (-1)
        }
    },
    ready: function () {
        this.showView(this.currentViewName);
        this.initializeControls();
        this.getNotes();
        $('#inputDate').datetimepicker();
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
        initializeControls: function () {
            var self = this;
            $("#grid-selection").bootgrid({
                navigation: 0,
                selection: true,
                rowSelect: false,
                multiSelect: false
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
                    self.lastRowId = item.id;
                    self.setNoteEditModel(item);
                }
            }).on("deselected.rs.jquery.bootgrid", function () {
                self.rowSelected = false;
            });
        },
        getNotes: function () {
            var self = this;
            self.lastRowId = 0;
            self.rowSelected = false;
            $.ajax({
                url: '/api/Note/GetAll',
                success: function (data) {
                    self.setNotesControl(data);
                }
            });
        },
        setNoteEditModel: function (item) {
            this.noteEditModel.id = item.id;
            this.noteEditModel.name = item.name;
            this.noteEditModel.text = item.text;
            $('#inputDate').data('DateTimePicker').locale(moment.locale());
            var date = new Date(item.date);
            $('#inputDate').data('DateTimePicker').date(date);
        },
        setNotesControl: function (data) {
            $("#grid-selection").bootgrid("clear");
            $("#grid-selection").bootgrid("append", data);
        },
        editNote: function () {
            this.showView("edit");
        },
        saveNote: function () {
            var date = $('#inputDate').data('DateTimePicker').date().utc().format();
            this.noteEditModel.date = date;

            var self = this;
            $.ajax({
                url: '/api/Note',
                type: "post",
                contentType: 'application/json',
                data: JSON.stringify(this.noteEditModel),
                'dataType': 'json',
                success: function () {
                    self.getNotes();
                    self.goHomeClick();
                }
            });
        }
    }
});