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
			var strRaps = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'rap_id', 'rap_type', 'rap_descr'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'rap/ext_get_all',
					method: 'POST'
				})
			});
			
			// the new search field
			var searchRaps = new Ext.app.SearchField({
			store: strRaps,
			params: {start: 0, limit: 10},
			width: 180,
			id: 'fieldRapsSearch'
			});


			var tbRaps = new Ext.Toolbar({
            items:[{
                text: 'Добавить',
                icon: BASE_ICONS + 'add.png',
                handler: function() {
                    var Rap = gridRaps.getStore().recordType;
                    var r = new Rap({
                        rap_type: 'Новая запись',
						rap_descr: 'Новое описание'
                    });
                    gridRaps.stopEditing();
                    strRaps.insert(0, r);
                    gridRaps.startEditing(0, 0);
                }
            }, '-', {
                text: 'Сохранить выбранные',
                disabled: true,
                id: 'btnSave',
                icon: BASE_ICONS + 'save.gif',
                handler: updateRaps
            }, '-', {
                text: 'Удалить',
                icon: BASE_ICONS + 'delete.png',
                handler: deleteRaps
            }, '->', searchRaps]
        });

		function updateRaps() {
			var sm = gridRaps.getSelectionModel();
			var sel = sm.getSelections();
			var data = '';
			for (i = 0; i<sel.length; i++) {
				data = data + sel[i].get('rap_id') + ';'
						+ sel[i].get('rap_type')
						+ ';' + sel[i].get('rap_descr')
						+ '||';
			}
			Ext.Ajax.request({
				url: BASE_URL + 'rap/ext_update',
				method: 'POST',
				params: { postdata: data }
			});
			strRaps.load();
		}
			
		function deleteRaps() {
					Ext.Msg.show({
						title: 'Подтверждение',
						msg: 'Удалить выбранные наказания/поощрения?',
						buttons: Ext.Msg.YESNO,
						fn: function(btn) {
							if (btn == 'yes') {
								var sm = gridRaps.getSelectionModel();
								var sel = sm.getSelections();
								var data = '';
								for (i = 0; i<sel.length; i++) {
									data = data + sel[i].get('rap_id') + ';';
								}
								Ext.Ajax.request({
									url: BASE_URL + 'rap/ext_delete',
									method: 'POST',
									params: { postdata: data }
								});
								strRaps.load();
							}
						}
					});
				}

        var cbGrid = new Ext.grid.CheckboxSelectionModel();

        var gridRaps = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, sm: cbGrid,
            store: strRaps, loadMask: true, title: 'Список наказаний и поощрений',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                cbGrid, {
                    header: "Тип",
                    dataIndex: 'rap_type',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false
                    })
                }, {
                    header: "Краткое описание",
                    dataIndex: 'rap_descr',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
				}
            ],
            listeners: {
                'rowclick': function() {
                    var sm = gridRaps.getSelectionModel();
                    var sel = sm.getSelections();
                    if (sel.length == 0) {
                        Ext.getCmp('btnSave').setDisabled(true);
                    } else {
                        Ext.getCmp('btnSave').setDisabled(false);
                    }
                }
            },
            tbar: tbRaps,
            bbar: new Ext.PagingToolbar({
                pageSize: 25,
                store: strRaps,
                displayInfo: true
            })
        });

        gridRaps.render('rapgrid');
        strRaps.load();
    });
	</script>
	
    <style type="text/css">
        #rapgrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>

    <title>Управление должностями</title>
</head>

<body>
	<div id="rapgrid"></div>
</body>

</html>