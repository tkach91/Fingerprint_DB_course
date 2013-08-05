<?php header('Content-Type: text/html; charset=utf-8'); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Данные о пользователе</title>
</head>

<body>
	<div id="uinfo"><?php
		if ($show_user->num_rows() > 0)
		{
			echo "Отпечаток принадлежит пользователю со следующими данными:<br>";
			foreach($show_user->result_array() as $row)
			{
				echo "Логин: " . $row['emp_login'] . "<br>";
				echo "Имя: " . $row['emp_first_name']. "<br>";
				echo "Фамилия: " . $row['emp_last_name']. "<br>";
				echo "Отдел: " . $row['d_division']. "<br>";
				echo "Должность: " . $row['p_post']. "<br>";
			}
		}
		else
			echo "отпечаток не принадлежит кому-либо из зарегистрированных в системе пользователей";?>
	</div>
</body>
</html>