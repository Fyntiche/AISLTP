$(function () {
    $("#jqGrid").jqGrid({
        url: "/Sotr/GetSotr",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'Код сотрудника', 'Фамилия', 'Имя', 'Отчество', 'Дата рождения', 'Пол', 'Дата создания'],
        colModel: [
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },
            { key: false, name: 'Cod_sotr', index: 'Cod_sotr', editable: true  },
            { key: false, name: 'Fio', index: 'Fio', editable: true },
            { key: false, name: 'Ima', index: 'Ima', editable: true },
            { key: false, name: 'Otc', index: 'Otc', editable: true },
            { key: false, name: 'Dr', index: 'Dr', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' }, search: false },
            { key: false, name: 'Sex', index: 'Sex', editable: true, search: false },
            { key: false, name: 'Dvi', index: 'Dvi', editable: true, formatter: 'date', formatoptions: { newformat: 'd/m/Y' }, search: false }],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Записи сотрудников',
        emptyrecords: 'Нет записей сотрудников для отображения',
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
        searchtext: "Поиск сотрудника", refresh: true
    },
        {
            zIndex: 100,
            url: '/Sotr/Edit',
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
            url: "/Sotr/Create",
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
            url: "/Sotr/Delete",
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
            caption: "Поиск сотрудника",
            sopt: ['cn']
        });
});


