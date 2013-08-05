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
			var strEmployees = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'emp_id', 'emp_login', 'emp_pass', 'emp_first_name',
						'emp_last_name', 'emp_post_id', 'emp_divi_id','emp_photo',
						'division_id', 'd_division', 'division_base_screw',
						'division_descr', 'post_id', 'p_post', 'post_screw', 'ismanager'  
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'employee/ext_get_all',
					method: 'POST'
				})
			});
			
		// the new search field
		var searchEmployees = new Ext.app.SearchField({
		store: strEmployees,
		params: {start: 0, limit: 10},
		width: 180,
		id: 'fieldEmployeesSearch'
		});

		var tbEmployees = new Ext.Toolbar({
            items:[{
                text: 'Сохранить выбранные',
                disabled: true,
                id: 'btnSave',
                icon: BASE_ICONS + 'save.gif',
                handler: updateEmployees
            }, '-', {
                text: 'Удалить',
                icon: BASE_ICONS + 'delete.png',
                handler: deleteEmployees
            }, '->', searchEmployees]
        });

		function updateEmployees() {
			var sm = gridEmployees.getSelectionModel();
			var sel = sm.getSelections();
			var data = '';
			for (i = 0; i<sel.length; i++) {
				data = data + sel[i].get('emp_id') + ';'
						+ sel[i].get('emp_login')
						+ ';' + sel[i].get('emp_first_name')
						+ ';' + sel[i].get('emp_last_name')
						+ ';' + sel[i].get('emp_post_id')
						+ ';' + sel[i].get('emp_divi_id')
						+ '||';
			}
			Ext.Ajax.request({
				url: BASE_URL + 'employee/ext_update',
				method: 'POST',
				params: { postdata: data }
			});
			strEmplyees.load();
		}
		
		function deleteEmployees() {
					Ext.Msg.show({
						title: 'Подтверждение',
						msg: 'Удалить выбранные должности?',
						buttons: Ext.Msg.YESNO,
						fn: function(btn) {
							if (btn == 'yes') {
								var sm = gridEmployees.getSelectionModel();
								var sel = sm.getSelections();
								var data = '';
								for (i = 0; i<sel.length; i++) {
									data = data + sel[i].get('emp_id') + ';';
								}
								Ext.Ajax.request({
									url: BASE_URL + 'eemployee/ext_delete',
									method: 'POST',
									params: { postdata: data }
								});
								strEmployees.load();
							}
						}
					});
				}
		
        var cbGrid = new Ext.grid.CheckboxSelectionModel();

        var gridEmployees = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, sm: cbGrid,
            store: strEmployees, loadMask: true, title: 'Список сотрудников',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                cbGrid, {
                    header: "Логин",
                    dataIndex: 'emp_login',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false
                    })
                }, {
                    header: "Имя",
                    dataIndex: 'emp_first_name',
                    sortable: true,
					batch: true,
                    width: 180,
                    editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
                }, {
                    header: "Фамилия",
                    dataIndex: 'emp_last_name',
                    sortable: true,
					batch: true,
                    width: 120,
					editor: new Ext.form.TextField({
                        allowBlank: false,
                    })
                }, {
                    header: "Должность",
                    dataIndex: 'p_post',
                    sortable: true,
					batch: true,
                    width: 250,
					editor: new Ext.form.ComboBox({
						typeAhead: true,
						editable: false,
						triggerAction: 'all',
						transform: 'post',
						lazyRender: true,
						listClass: 'x-combo-list-small'
				})
                }, {
                    header: "Отдел",
                    dataIndex: 'd_division',
                    sortable: true,
					batch: true,
                    width: 250,
					editor: new Ext.form.ComboBox({
						typeAhead: true,
						editable: false,
						triggerAction: 'all',
						transform: 'division',
						lazyRender: true,
						listClass: 'x-combo-list-small'
				})
                }
            ],
            listeners: {
                'rowclick': function() {
                    var sm = gridEmployees.getSelectionModel();
                    var sel = sm.getSelections();
                    if (sel.length == 0) {
                        Ext.getCmp('btnSave').setDisabled(true);
                    } else {
                        Ext.getCmp('btnSave').setDisabled(false);
                    }
                }
            },
            tbar: tbEmployees,
            bbar: new Ext.PagingToolbar({
                pageSize: 25,
                store: strEmployees,
                displayInfo: true
            })
        });

        gridEmployees.render('employeegrid');
        strEmployees.load();
    });
	</script>
    <title>Управление отделами</title>
	<style type="text/css">
        #employeegrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>
</head>

<body>
	<div id="employeegrid"></div>
	<select name='post' id='post' style="display: none;">>
	<? 
		foreach($posts->result_array() as $row)
		{
			$id = $row['post_id'];
			$name = $row['p_post'];
			echo "<option value=$id>$name</option>";
		}
	?>
	</select>
	<select name='division' id='division' style="display: none;">>
	<? 
		foreach($divisions->result_array() as $row) 
		{
			$id = $row['division_id'];
			$name = $row['d_division'];
			echo "<option value=$id>$name</option>";	
		}
	?>
	</select>
</body>

</html>