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
			var strPosts = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'post_id', 'p_post', 'post_screw', 'ismanager'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'post/ext_get_all',
					method: 'POST'
				})
			});
			
			// the new search field
			var searchPosts = new Ext.app.SearchField({
			store: strPosts,
			params: {start: 0, limit: 10},
			width: 180,
			id: 'fieldPostsSearch'
			});


			var tbPosts = new Ext.Toolbar({
            items:[{
                text: 'Добавить',
                icon: BASE_ICONS + 'add.png',
                handler: function() {
                    var Post = gridPosts.getStore().recordType;
                    var p = new Post({
                        p_post: 'Новая должность',
						post_screw: '0.00',
						ismanager: 'Сотрудник'
                    });
                    gridPosts.stopEditing();
                    strPosts.insert(0, p);
                    gridPosts.startEditing(0, 0);
                }
            }, '-', {
                text: 'Сохранить выбранные',
                disabled: true,
                id: 'btnSave',
                icon: BASE_ICONS + 'save.gif',
                handler: updatePosts
            }, '-', {
                text: 'Удалить',
                icon: BASE_ICONS + 'delete.png',
                handler: deletePosts
            }, '->', searchPosts]
        });

		function updatePosts() {
			var sm = gridPosts.getSelectionModel();
			var sel = sm.getSelections();
			var data = '';
			for (i = 0; i<sel.length; i++) {
				data = data + sel[i].get('post_id') + ';'
						+ sel[i].get('p_post')
						+ ';' + sel[i].get('post_screw')
						+ ';' + sel[i].get('ismanager')
						+ '||';
			}
			Ext.Ajax.request({
				url: BASE_URL + 'post/ext_update',
				method: 'POST',
				params: { postdata: data }
			});
			strPosts.load();
		}

					
		function deletePosts() {
					Ext.Msg.show({
						title: 'Подтверждение',
						msg: 'Удалить выбранные должности?',
						buttons: Ext.Msg.YESNO,
						fn: function(btn) {
							if (btn == 'yes') {
								var sm = gridPosts.getSelectionModel();
								var sel = sm.getSelections();
								var data = '';
								for (i = 0; i<sel.length; i++) {
									data = data + sel[i].get('post_id') + ';';
								}
								Ext.Ajax.request({
									url: BASE_URL + 'post/ext_delete',
									method: 'POST',
									params: { postdata: data }
								});
								strPosts.load();
							}
						}
					});
				}

        var cbGrid = new Ext.grid.CheckboxSelectionModel();

        var gridPosts = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, sm: cbGrid,
            store: strPosts, loadMask: true, title: 'Список должностей',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                cbGrid, {
                    header: "Название",
                    dataIndex: 'p_post',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false
                    })
                }, {
                    header: "Надбавка к З/П",
                    dataIndex: 'post_screw',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
                }, {
                    header: "Статус",
                    dataIndex: 'ismanager',
                    sortable: true,
					batch: true,
                    width: 120,
					editor: new Ext.form.ComboBox({
						typeAhead: true,
						editable: false,
						triggerAction: 'all',
						transform: 'ismanager',
						lazyRender: true,
						listClass: 'x-combo-list-small'
				})
                }
            ],
            listeners: {
                'rowclick': function() {
                    var sm = gridPosts.getSelectionModel();
                    var sel = sm.getSelections();
                    if (sel.length == 0) {
                        Ext.getCmp('btnSave').setDisabled(true);
                    } else {
                        Ext.getCmp('btnSave').setDisabled(false);
                    }
                }
            },
            tbar: tbPosts,
            bbar: new Ext.PagingToolbar({
                pageSize: 25,
                store: strPosts,
                displayInfo: true
            })
        });

        gridPosts.render('postgrid');
        strPosts.load();
    });
	</script>
	
    <style type="text/css">
        #postgrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>

    <title>Управление должностями</title>
</head>

<body>
	<div id="postgrid"></div>
	<select name="ismanager" id="ismanager" style="display: none;">
    	<option value="Сотрудник">Сотрудник</option>
    	<option value="Глава отдела">Глава отдела</option>
    	<option value="Глава производства">Глава производства</option>
    </select>
	<select name="hlarge" id="hlarge" style="display: none;">
    	<option value="smaller">Меньше</option>
    	<option value="bigger">Больше</option>
    	<option value="eq">Равна</option>
    </select>
</body>

</html>