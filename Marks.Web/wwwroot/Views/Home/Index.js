(function ($) {
	var jtableData = {
		Result: 'OK',
		Records: [],
		TotalRecordCount: 0
	};
	$(document).ready(function () {
		$('#peopleTable').jtable({
			title: 'People',
			paging: true,
			pageSize: 10,
			sorting: true,
			defaultSorting: 'Id desc',
			actions: {
				listAction: function (postData, jtParams) {
					var xhttp = new XMLHttpRequest();
					var sorting = "Id desc";
					if (jtParams.jtSorting) {
						sorting = jtParams.jtSorting.replace(/fullName ASC/gi, "firstName asc, lastName asc");
						sorting = sorting.replace(/fullName DESC/gi, "firstName desc, lastName desc");
						sorting = sorting.replace(/mark/gi, "mark.value");
					}
					xhttp.open("GET", "api?skip=" + jtParams.jtStartIndex + "&take=" + jtParams.jtPageSize + "&sorting=" + sorting, false);
					xhttp.send();

					var data = JSON.parse(xhttp.response);

					jtableData.Result = "OK";
					jtableData.Records = data.result.items;
					jtableData.TotalRecordCount = data.result.totalCount;

					return jtableData;
				}
			},
			fields: {
				id: {
					key: true,
					list: false
				},
				fullName: {
					title: 'Full Name',
					width: '60%'
				},
				mark: {
					title: 'Mark',
					width: '40%'
				}
			}
		});

		$('#peopleTable').jtable('load');

		$('#createRecord').click(function (e) {
			e.preventDefault();

			$('#modDialog').modal('toggle');
		});

		$('#savePeople').click(function (e) {
			e.preventDefault();

			debugger
			if (!$('#peopleForm').valid()) {
				return;
			}

			var params = {
				fullName: $('#fullNameInput').val(),
				mark: $('#markInput').val(),
			};

			$.ajax({
				url: 'api',
				type: 'POST',
				dataType: 'json',
				contentType: "application/json; charset=utf-8",
				data: JSON.stringify(params),
				success: function () {
					debugger
					$('#fullNameInput').val('');
					$('#markInput').val('');
					$('#errorMessage').css('display', 'none');
					$('#peopleTable').jtable('load');
					
					$('#modDialog').modal('hide');
				},
				error: function (data) {
					debugger
					$('#errorMessage').html(data.responseJSON.errorMessage);
					$('#errorMessage').css('display', 'block');
				}
			});
		});
	});
})(jQuery)