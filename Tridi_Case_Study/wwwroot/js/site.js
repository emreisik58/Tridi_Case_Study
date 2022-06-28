var tridiLib = {
	toUserClick: function (toUserDiv) {
		$('#toUser')[0].innerHTML = '';
		var id = $(toUserDiv).attr('userid');
		var img = $(toUserDiv).find('img').attr('src');
		var fullName = $(toUserDiv).attr('fullName');

		$('#toUser').append('<img src="' + img +'" alt="" class="img-avatar m-r-10"><div class="lv-avatar pull-left"></div><span>' + fullName+'</span>');


		$('#msb-reply').show();

	}
}
