<?php
class Main extends MY_Controller {
	
	public function __construct()
	{
		parent::__construct();
	}
	
	function index()
    {
		if ($this->session->userdata('logon') === 'Yes')
		{
			$data['info'] = $this->get_user_info();
			$this->load->view('mainmview', $data);
			$this->load->view('mainview', $data);
			echo 'Добро пожаловать!';
		}
		else
		{
			echo "Авторизуйтесь под другой учетной записью!";
		}
	}
}