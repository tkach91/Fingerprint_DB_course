<?php
if (!defined('BASEPATH')) exit('Нет доступа к скрипту'); 

class MY_Controller extends CI_Controller {

	private $head; 
	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('login_model');
		$this->load->helper('form');
		$this->load->helper('url');
		$this->load->library('session');
		$this->load->database();
	}
	
	// Вход
	function login($hash)
    {
		// Пользователь уже вошёл
		if ($this->session->userdata('logon') === 'Yes')
		{
			redirect('main');
		}
		else
		{
			$query = $this->login_model->get_login_data($hash);
			foreach ($query->result_array() as $row)
				// Проверяем соответствие нашей строки данным из базы
				if ($row['hash'] === $hash)
				{	
					// Записываем в сессию признак логона
					$session_data = array('logon'=>'Yes', 'emp_id' => $row['emp_id'], 'emp_login'=>$row['emp_login'], 
										  'emp_first_name' => $row['emp_first_name'],
										  'emp_last_name' => $row['emp_last_name'], 'division' => $row['d_division'],
										  'emp_post' => $row['p_post'], 'emp_stat' => $row['ismanager']);
					$this->session->set_userdata($session_data);
					$this->login_model->addLoginTime($row['emp_id']);
					$this->login_model->del_hash($row['emp_id']);
					redirect(''); // редирект на главную страницу
				}
				else
				{
					echo 'Неверные данные!';
				}
		}
    }
	
	// Выход
	function logout()
    { 
		$this->login_model->addLogonTime($this->session->userdata('emp_id'));
		$this->session->sess_destroy();  // обнуляем сессию
        redirect(''); // редирект на главную страницу
    }
	
	// Формируем общую информацию для пользователя
	function get_user_info()
	{
		// id
		$info['id'] = $this->session->userdata('emp_id');
		// Логин
		$info['login'] = $this->session->userdata('emp_login');
		// Имя
		$info['f_name'] = $this->session->userdata('emp_first_name');
		// Фамилия
		$info['l_name'] = $this->session->userdata('emp_last_name');
		// Должность
		$info['post'] = $this->session->userdata('emp_post');
		// Отдел	
		$info['division'] = $this->session->userdata('division');
		// Статус: менеджер / пользователь
		$info['usr_status'] = $this->session->userdata('emp_stat');
		
		return $info;
	}
}