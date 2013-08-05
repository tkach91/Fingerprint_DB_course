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
			var strFingers = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'fing_id', 'fing_emp_id', 'fing_dactil', 'fing_number',
						'emp_id', 'emp_login', 'emp_pass', 'emp_first_name',
						'emp_last_name', 'emp_post_id', 'emp_divi_id','emp_photo',
						'dacti_id', 'dacti_photo'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'fingers/ext_get_all',
					method: 'POST'
				})
			});

		var tbFingers = new Ext.Toolbar({
		items:[{
			text: 'Удалить',
			icon: BASE_ICONS + 'delete.png',
			handler: deleteFingers
		}]
        });
		
		function deleteFingers() {
					Ext.Msg.show({
						title: 'Подтверждение',
						msg: 'Удалить выбранные отпечатки??',
						buttons: Ext.Msg.YESNO,
						fn: function(btn) {
							if (btn == 'yes') {
								var sm = gridFingers.getSelectionModel();
								var sel = sm.getSelections();
								var data = '';
								for (i = 0; i<sel.length; i++) {
									data = data + sel[i].get('fing_id') + ';';
								}
								Ext.Ajax.request({
									url: BASE_URL + 'fingers/ext_delete',
									method: 'POST',
									params: { postdata: data }
								});
								strFingers.load();
							}
						}
					});
				}
		
        var cbGrid = new Ext.grid.CheckboxSelectionModel();

        var gridFingers = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, sm: cbGrid,
            store: strFingers, loadMask: true, title: 'Ваши отпечатки',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                cbGrid, {
                    header: "Палец",
                    dataIndex: 'fing_number',
                    sortable: true,
					batch: true,
                    width: 180
                }, {
                    header: "Отпечаток",
                    dataIndex: 'dacti_photo',
                    sortable: true,
					batch: true,
                    width: 550
				}
            ],
            tbar: tbFingers,
            bbar: new Ext.PagingToolbar({
                pageSize: 25,
                store: strFingers,
                displayInfo: true
            })
        });

        gridFingers.render('fingergrid');
        strFingers.load();
    });
	</script>
    <title>Управление отпечатками</title>
	<style type="text/css">
        #fingergrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>
</head>

<body>
	<div id="fingergrid"></div>
</body>

</html>