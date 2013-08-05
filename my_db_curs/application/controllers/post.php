<?php

class Post extends MY_Controller 
{
	public function __construct()
	{
		parent::__construct();
		$this->load->database();
		$this->load->model('posts_model');
	}
	
	function index()
	{
		if (($this->session->userdata('logon') === 'Yes') & ($this->session->userdata('emp_stat') != 'Сотрудник'))
		{
			$data['info'] = $this->get_user_info();
			$this->load->view('mainmview', $data);
			$this->load->view('post/indexview');
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
			
			
	    $query = $this->posts_model->get_data($start, $limit, $tmp);
	    $results = $query->num_rows(); //$this->posts_model->get_count();
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
			
			if (isset($field[1]) && isset($field[2]) && isset($field[3]))	
				$data = array(
					'p_post' => $field[1],
					'post_screw' => $field[2],
					'ismanager' => $field[3]
				);
			else
				exit;

			if (is_numeric($field[0]))
			{
				$this->posts_model->update($field[0], $data);
			}
			else
			{
				$this->posts_model->insert($data);
			}
		}
	}
	
	public function ext_delete()
    {
        $records = explode(';', $_POST['postdata']);
		
        foreach($records as $id)
        {
			if (is_numeric($id))
				$this->posts_model->delete($id);
        }
    }
}
	
?>