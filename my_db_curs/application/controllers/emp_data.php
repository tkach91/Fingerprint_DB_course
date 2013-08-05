<?php
class Emp_data extends MY_Controller {
	
	public function __construct()
	{
		parent::__construct();
		$this->load->model('employees_model');
	}
	
	function index()
    {
	}
	
	function get_emp_data($id)
	{
		if (($this->session->userdata('logon') === 'Yes'))
		{
			$data['info'] = $this->get_user_info();
			$data['show_user'] = $this->employees_model->get_emp_data($id);
			$this->load->view('mainmview', $data);
			$this->load->view('employee/empdataview', $data);
			echo 'Добро пожаловать!';
		}
		else
		{
			echo "У вас недостаточно прав или вы не вошли в систему. Авторизуйтесь под другой учетной записью!";
		}
	}
}