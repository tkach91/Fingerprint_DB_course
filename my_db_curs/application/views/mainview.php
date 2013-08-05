<?php header('Content-Type: text/html; charset=utf-8'); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title>Главная страница системы</title>
</head>
<body>
		<b>Ваш логин:</b> <?php echo $info['login'];?><br/>
		<b>Вы вошли как:</b> <?php echo $info['f_name'] . ' ' .$info['l_name'];?><br/>	
		<b>Ваша должность:</b> <?php echo $info['post'];?><br/>
		<b>Ваш отдел:</b> <?php echo $info['division'];?><br/>	
		<b>Ваш статус:</b> <?php echo $info['usr_status'];?><br/><br/>
</body>
</html>