<?php

class Employee extends MY_Controller 
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
			$data['posts'] = $this->employees_model->get_posts();
			$data['divisions'] = $this->employees_model->get_divisions();
			$data['info'] = $this->get_user_info();
			$this->load->view('mainmview', $data);
			$this->load->view('employee/indexview', $data);
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
		
		if (isset($_POST['query']))
			$tmp = $_POST['query'];
		else
			$tmp = '';
			
	    $query = $this->employees_model->get_data($start, $limit, $tmp);
	    $results = $query->num_rows(); //$this->employees_model->get_count();
	    $arr = array();
	    
	    foreach ($query->result() as $obj)
	    {
	    	$arr[] = $obj;
	    }
	    
	    echo '{success:true,results:'. $results .
	                ',rows:'.json_encode($arr).'}';
    }
	
	function ext_update()
	{

		$records = explode('||', $_POST['postdata']);

		foreach ($records as $row)
		{
			$field = explode(';', $row);
			
			$posts = $this->employees_model->get_posts();
			$p = $field[5];
			$field[5] = 27;
			foreach ($posts->result_array() as $row1)
			{
				if ($p == $row1['p_post'])
					$field[5] = $row1['post_id'];	
			}
			
			$divisions = $this->employees_model->get_divisions();
			$d = $field[6];
			$field[6] = 4;
			foreach ($divisions->result_array() as $row1)
			{
				if ($d == $row1['d_division'])
					$field[6] = $row1['division_id'];
			}
			
			// Если у нас апдейт
			if (isset($field[0]))
			{
				$data = array();
				if (isset($field[1]))
					$data['emp_login'] = $field[1];
				if (isset($field[2]))
					$data['emp_pass'] = md5($field[2]);
				if (isset($field[3]))
					$data['emp_first_name'] = $field[3];
				if (isset($field[4]))
					$data['emp_last_name'] = $field[4];
				if (isset($field[5]) & is_numeric($field[5]))
					$data['emp_post_id'] = $field[5];
				if (isset($field[6]) & is_numeric($field[6]))
					$data['emp_divi_id'] = $field[6];
			}
			// А это, если инсерт)
			else
				if (isset($field[1]) && isset($field[2]) && isset($field[3]) 
				 && isset($field[4]) && isset($field[5]) && isset($field[6]))	
					$data = array(
						'emp_login' => $field[1],
						'emp_pass' => $field[2],
						'emp_first_name' => $field[3],
						'emp_last_name' => $field[4],
						'emp_post_id' => $field[5],
						'emp_divi_id' => $field[6]
					);
			else
				exit;

			if (is_numeric($field[0]))
			{
				$this->employees_model->update($field[0], $data);
			}
			else
			{
				$this->employees_model->insert($data);
			}
		}
	}
	
	public function ext_delete()
    {
        $records = explode(';', $_POST['postdata']);
		
        foreach($records as $id)
        {
			if (is_numeric($id))
				$this->employees_model->delete($id);
        }
    }
}
	
?>