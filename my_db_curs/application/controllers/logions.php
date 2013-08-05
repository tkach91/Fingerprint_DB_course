<?php

class Logions extends MY_Controller 
{
	public function __construct()
	{
		parent::__construct();
		$this->load->model('employees_model');
	}
	
	function index()
	{
		if ($this->session->userdata('logon') === 'Yes')
		{
			$data['info'] = $this->get_user_info();
			$this->load->view('mainmview', $data);
			$this->load->view('employee/logions');
		}
		else
		{
			echo "јвторизуйтесь, использу€ приложение!";
		}
	}
	
    function ext_get_all_logins()
    {	
	    $query = $this->employees_model->getAllLogins($this->session->userdata('emp_id'));
	    $results = $query->num_rows(); //$this->divisions_model->get_count();
	    $arr = array();
	    
	    foreach ($query->result() as $obj)
	    {
	    	$arr[] = $obj;
	    }
	    
	    echo '{success:true,results:'. $results .
	                ',rows:'.json_encode($arr).'}';
    }
	
	function ext_get_all_logons()
     {	
	    $query = $this->employees_model->getAllLogons($this->session->userdata('emp_id'));
	    $results = $query->num_rows(); //$this->divisions_model->get_count();
	    $arr = array();
	    
	    foreach ($query->result() as $obj)
	    {
	    	$arr[] = $obj;
	    }
	    
	    echo '{success:true,results:'. $results .
	                ',rows:'.json_encode($arr).'}';
    }
}
	
?>