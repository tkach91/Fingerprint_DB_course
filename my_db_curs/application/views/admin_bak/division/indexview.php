<?php header('Content-Type: text/html; charset=utf-8'); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="http://db.loc/assets/js/ext/resources/css/ext-all.css"/>

    <script type="text/javascript" src="http://db.loc/assets/js/ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="http://db.loc/assets/js/ext/ext-all.js"></script>
	<script type="text/javascript" src="http://db.loc/assets/js/ext/plugins/searchfield.js"></script>
	
    <script type="text/javascript">
		var BASE_URL = 'http://db.loc/index.php/';
		var BASE_PATH = 'http://db.loc/';
		var BASE_ICONS = 'http://db.loc/assets/icons/';
		
		Ext.onReady(function() {
			var strDivisions = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'division_id', 'd_division', 'division_base_screw', 'division_descr'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'division/ext_get_all',
					method: 'POST'
				})
			});
			
			// the new search field
			var searchDivisions = new Ext.app.SearchField({
			store: strDivisions,
			params: {start: 0, limit: 10},
			width: 180,
			id: 'fieldDivisionsSearch'
			});

			var tbDivisions = new Ext.Toolbar({
            items:[{
                text: 'Добавить',
                icon: BASE_ICONS + 'add.png',
                handler: function() {
                    var Division = gridDivisions.getStore().recordType;
                    var d = new Division({
                        d_division: 'Новый отдел',
						division_base_screw: '0.00',
						division_descr: 'Информация об отделе'
                    });
                    gridDivisions.stopEditing();
                    strDivisions.insert(0, d);
                    gridDivisions.startEditing(0, 0);
                }
            }, '-', {
                text: 'Сохранить выбранные',
                disabled: true,
                id: 'btnSave',
                icon: BASE_ICONS + 'save.gif',
                handler: updateDivisions
            }, '-', {
                text: 'Удалить',
                icon: BASE_ICONS + 'delete.png',
                handler: deleteDivisions
            }, '->', searchDivisions]
        });

		function updateDivisions() {
			var sm = gridDivisions.getSelectionModel();
			var sel = sm.getSelections();
			var data = '';
			for (i = 0; i<sel.length; i++) {
				data = data + sel[i].get('division_id') + ';'
						+ sel[i].get('d_division')
						+ ';' + sel[i].get('division_base_screw')
						+ ';' + sel[i].get('division_descr')
						+ '||';
			}
			Ext.Ajax.request({
				url: BASE_URL + 'division/ext_update',
				method: 'POST',
				params: { postdata: data }
			});
			strDivisions.load();
		}

					
		function deleteDivisions() {
					Ext.Msg.show({
						title: 'Подтверждение',
						msg: 'Удалить выбранные должности?',
						buttons: Ext.Msg.YESNO,
						fn: function(btn) {
							if (btn == 'yes') {
								var sm = gridDivisions.getSelectionModel();
								var sel = sm.getSelections();
								var data = '';
								for (i = 0; i<sel.length; i++) {
									data = data + sel[i].get('division_id') + ';';
								}
								Ext.Ajax.request({
									url: BASE_URL + 'division/ext_delete',
									method: 'POST',
									params: { postdata: data }
								});
								strDivisions.load();
							}
						}
					});
				}
		
        var cbGrid = new Ext.grid.CheckboxSelectionModel();

        var gridDivisions = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, sm: cbGrid,
            store: strDivisions, loadMask: true, title: 'Список отделов',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                cbGrid, {
                    header: "Название",
                    dataIndex: 'd_division',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false
                    })
                }, {
                    header: "Базовая ставка",
                    dataIndex: 'division_base_screw',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
                }, {
                    header: "Описание",
                    dataIndex: 'division_descr',
                    sortable: true,
					batch: true,
                    width: 120,
					editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
                }
            ],
            listeners: {
                'rowclick': function() {
                    var sm = gridDivisions.getSelectionModel();
                    var sel = sm.getSelections();
                    if (sel.length == 0) {
                        Ext.getCmp('btnSave').setDisabled(true);
                    } else {
                        Ext.getCmp('btnSave').setDisabled(false);
                    }
                }
            },
            tbar: tbDivisions,
            bbar: new Ext.PagingToolbar({
                pageSize: 25,
                store: strDivisions,
                displayInfo: true
            })
        });

        gridDivisions.render('divisiongrid');
        strDivisions.load();
    });
	</script>
	
    <style type="text/css">
        #divisiongrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>

    <title>Управление отделами</title>
</head>

<body>
	<div id="divisiongrid"></div>
</body>

</html>