<?php header('Content-Type: text/html; charset=utf-8'); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <link rel="stylesheet" type="text/css" href="http://db.loc/assets/js/ext/resources/css/ext-all.css"/>

    <script type="text/javascript" src="http://db.loc/assets/js/ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="http://db.loc/assets/js/ext/ext-all.js"></script>
	
    <script type="text/javascript">
		var BASE_URL = 'http://db.loc/index.php/';
		var BASE_PATH = 'http://db.loc/';
		var BASE_ICONS = 'http://db.loc/assets/icons/';
		
		Ext.onReady(function() {
			var strLogins = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'id', 'l_u_id', 'l_login_day', 'l_login_time'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'logions/ext_get_all_logins',
					method: 'POST'
				})
			});
			
			var strLogons = new Ext.data.Store({
				reader: new Ext.data.JsonReader({
					fields: [
						'id', 'l_u_id', 'l_logon_day', 'l_logon_time'
					],
					root: 'rows', 
					totalProperty: 'results'
				}),
				proxy: new Ext.data.HttpProxy({
					url: BASE_URL + 'logions/ext_get_all_logons',
					method: 'POST'
				})
			});

        var gridLogins = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, 
            store: strLogins, loadMask: true, title: 'Список входов',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                {
                    header: "День",
                    dataIndex: 'l_login_day',
                    sortable: true,
					batch: true,
                    width: 180
                }, {
                    header: "Время",
                    dataIndex: 'l_login_time',
                    sortable: true,
					batch: true,
                    width: 180
                }]
            }); 
			
		var gridLogons = new Ext.grid.EditorGridPanel({
            frame: true, border: true, stripeRows: true, 
            store: strLogons, loadMask: true, title: 'Список выходов',
            style: 'margin:0 auto;', height: 615, width: 'auto',
            columns: [
                {
                    header: "День",
                    dataIndex: 'l_logon_day',
                    sortable: true,
					batch: true,
                    width: 180,
                }, {
                    header: "Время",
                    dataIndex: 'l_logon_time',
                    sortable: true,
					batch: true,
                    width: 180,
                }]
            });

        gridLogins.render('logingrid');
		gridLogons.render('logongrid');
        strLogins.load();
		strLogons.load();
    })
	
	</script>
    <title>Активность</title>
	<style type="text/css">
        #activitygrid {
            background: #e9e9e9;
            border: 1px solid #d3d3d3;
            margin: 20px;
            padding: 20px;
        }
    </style>
</head>

<body>
	<div id="logingrid"></div>
	<div id="logongrid"></div>
</body>

</html>