$(function () {
    $("#jqGrid").jqGrid({
        url: "/Court/GetCourt",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'Название', 'Населенный пункт', 'Улица', 'Дом', 'Почтовый индекс', 'Телефон дежурной службы', 'Электронная почта'],
        colModel: [
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },
            { key: false, name: 'Name', index: 'Nom', editable: true },
            { key: false, name: 'Np', index: 'Np', editable: true, search: false },
            { key: false, name: 'Ul', index: 'Ul', editable: true, search: false },
            { key: false, name: 'Dom', index: 'Dom', editable: true, search: false },
            { key: false, name: 'Pindex', index: 'Pindex', editable: true, search: false },
            { key: false, name: 'Teldej', index: 'Teldej', editable: true, search: false },
            { key: false, name: 'Email', index: 'Email', editable: true, search: false }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Список судов',
        emptyrecords: 'Нет записей',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', {
        edit: true, add: true, del: true, search: true,
        searchtext: "Поиск ЛТП", refresh: true
    },
        {
            zIndex: 100,
            url: '/Court/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Court/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Court/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Вы действительно хотите удалить эту запись?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            caption: "Поиск",
            sopt: ['cn']
        });
});


