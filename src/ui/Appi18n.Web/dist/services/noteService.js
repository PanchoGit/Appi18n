export default {
	getAll : function(context, callback)
	{
		var result = [];

		context.$http.get('http://localhost:62829/api/Skater/GetAll').then(callback);

		return result;
	}
}