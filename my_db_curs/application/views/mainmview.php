<html>
	<body>
	<div class="layout">	
		<div class="sidebar">
			<?php 
				echo '<div class="box">';
					echo '<h3>Главное меню</h3>';
					echo '<ul>';
						echo '<li>' . anchor('main', 'На главную') . '</li>';
						if (($info['usr_status'] === 'Глава отдела') | ($info['usr_status'] === 'Глава предприятия'))
						{
							echo  '<li>' . anchor('employee/', 'Управление сотрудниками') . '</li>';
						}
						if($info['usr_status'] === 'Глава предприятия')
						{
							echo  '<li>' . anchor('post/', 'Управление должностями') . '</li>';
							echo  '<li>' . anchor('division/', 'Управление отделами') . '</li>';
						}
						echo  '<li>' . anchor('logions', 'История активности') . '</li>';
						echo  '<li>' . anchor('fingers', 'Управление отпечатками') . '</li>';
						echo  '<li>' . anchor('main/logout', 'Выход') . '</li>';
					echo '</ul>';
				echo '</div>';
			?>
		</div>
	</body>
</html>