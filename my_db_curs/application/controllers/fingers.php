<?php

class Fingers extends MY_Controller 
{
	public function __construct()
	{
		parent::__construct();
		$this->load->model('employees_model');
	}
	
	function index()
	{
		if (($this->session->userdata('logon') === 'Yes') & ($this->session->userdata('emp_stat') != 'Сотрудник'))
		{
			$data['info'] = $this->get_user_info();
			$this->load->view('mainmview', $data);
			$this->load->view('employee/dactilosview', $data);
		}
		else
		{
			echo "Авторизуйтесь под другой учетной записью!";
		}
	}
	
    function ext_get_all()
    {
	    $start = isset($_REQUEST['start']) ? $_REQUEST['start'] : 0;
		$limit = isset($_REQUEST['limit']) ? $_REQUEST['limit'] : 25;
			
	    $query = $this->employees_model->get_user_finger($this->session->userdata('emp_id'), $start, $limit);
	    $results = $query->num_rows(); //$this->employees_model->get_count();
		
	    $arr = array();
	    
	    foreach ($query->result() as $obj)
	    {
			if ($obj->fing_number == 1)
				$obj->fing_number = 'Мизинец левой';
			elseif ($obj->fing_number == 2)
				$obj->fing_number = 'Безимянный левой';
			elseif ($obj->fing_number == 3)
				$obj->fing_number = 'Средний левой';
			elseif ($obj->fing_number == 4)
				$obj->fing_number = 'Указательный левой';
			elseif ($obj->fing_number == 5)
				$obj->fing_number = 'Большой левой';
			elseif ($obj->fing_number == 6)
				$obj->fing_number = 'Мизинец правой';
			elseif ($obj->fing_number == 7)
				$obj->fing_number = 'Безимянный правой';
			elseif ($obj->fing_number == 8)
				$obj->fing_number = 'Средний правой';
			elseif ($obj->fing_number == 9)
				$obj->fing_number = 'Указательный правой';
			elseif ($obj->fing_number == 10)
				$obj->fing_number = 'Большой правой';	
				
	    	$arr[] = $obj;
	    }
	    
	    echo '{success:true,results:'. $results .
	                ',rows:'.json_encode($arr).'}';
    }
	
	public function ext_delete()
    {
        $records = explode(';', $_POST['postdata']);
		
        foreach($records as $id)
        {
			if (is_numeric($id))
				$this->employees_model->drop_finger($id);
        }
    }
}
	
?>