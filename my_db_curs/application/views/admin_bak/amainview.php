<?php header('Content-Type: text/html; charset=utf-8'); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title>Главная страница системы</title>
    <link rel="stylesheet" type="text/css" href="http://db.loc/assets/js/ext/resources/css/ext-all.css" />
    
    <style type="text/css">
		html, body {
			font:normal 12px verdana;
			margin:0;
			padding:0;
			border:0 none;
			overflow:hidden;
			height:100%;
		}
		p {
			margin:5px;
		}
		.settings {
			background-image:url(../shared/icons/fam/folder_wrench.png);
		}
		.nav {
			background-image:url(../shared/icons/fam/folder_go.png);
		}
    </style>
	
    <!-- LIBS -->
    <script type="text/javascript" src="http://db.loc/assets/js/ext/adapter/ext/ext-base.js"></script>

    <!-- ENDLIBS -->

    <script type="text/javascript" src="http://db.loc/assets/js/ext/ext-all.js"></script>

    <!-- PLUGINS -->
    <script type="text/javascript" src="../shared/examples.js"></script> <script type="text/javascript" src="http://db.loc/assets/js/ext/plugins/post.js"></script>
  
    <script type="text/javascript">
    Ext.onReady(function(){
    
        // NOTE: This is an example showing simple state management. During development,
        // it is generally best to disable state management as dynamically-generated ids
        // can change across page loads, leading to unpredictable results.  The developer
        // should ensure that stable state ids are set for stateful components in real apps.
        Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
        
        var viewport = new Ext.Viewport({
            layout: 'border',
            items: [
            // create instance immediately
            new Ext.BoxComponent({
                region: 'north',
                height: 32, // give north and south regions a height
                autoEl: {
                    tag: 'div'
                }
            }), {
                // lazily created panel (xtype:'panel' is default)
                region: 'south',
                contentEl: 'south',
                split: true,
                height: 160,
                minSize: 100,
                maxSize: 200,
                collapsible: true,
                title: 'Личная информация',
                margins: '0 0 0 0'
            },
            // in this instance the TabPanel is not wrapped by another panel
            // since no title is needed, this Panel is added directly
            // as a Container
            new Ext.TabPanel({
                region: 'center', // a center region is ALWAYS required for border layout
                deferredRender: false,
                activeTab: 0,     // first tab initially active
                items: [{
                    contentEl: 'empInfo',
                    title: 'Сотрудники',
                    autoScroll: true
                }, {
                    contentEl: 'diviInfo',
                    title: 'Отделы',
                    autoScroll: true
                }, {
                    contentEl: 'postInfo',
                    title: 'Должности',
                    autoScroll: true
                }, {
                    contentEl: 'rapInfo',
                    title: 'Наказания/поощрения',
                    autoScroll: true
                }
				]
            })]
        });
        // get a reference to the HTML element with id "hideit" and add a click listener to it 
        Ext.get("hideit").on('click', function(){
            // get a reference to the Panel that was created with id = 'west-panel' 
            var w = Ext.getCmp('west-panel');
            // expand or collapse that Panel based on its collapsed property state
            w.collapsed ? w.expand() : w.collapse();
        });
    });
    </script>
</head>
<body>

    <!-- use class="x-hide-display" to prevent a brief flicker of the content -->
    <div id="empInfo" class="x-hide-display">
    </div>
	<div id="diviInfo" class="x-hide-display">
    </div>
	<div id="postInfo" class="x-hide-display">
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
    </div>
	<div id="rapInfo" class="x-hide-display">
    </div>
    <div id="props-panel" class="x-hide-display" style="width:200px;height:200px;overflow:hidden;"></div>
    <div id="south" class="x-hide-display">
		<b>Ваш логин:</b> <?php echo $info['login'];?><br/>
		<b>Вы вошли как:</b> <?php echo $info['f_name'] . ' ' .$info['l_name'];?><br/>	
		<b>Ваша должность:</b> <?php echo $info['post'];?><br/>
		<b>Ваш отдел:</b> <?php echo $info['division'];?><br/>	
		<b>Ваш статус:</b> <?php echo $info['usr_status'];?><br/><br/>
	<?php echo anchor('main/', 'Главная') . '<br>'; ?>
	<?php echo anchor('main/logout', 'Выход') . '<br>'; ?>
    </div>
</body>
</html>