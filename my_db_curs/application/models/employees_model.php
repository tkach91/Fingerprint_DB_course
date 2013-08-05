<?php
class Employees_model extends CI_Model 
{	
	function get_data($start, $limit, $search_param)
	{
		if (isset($search_param))
		{
			$this->db->like('divisions.d_division', $search_param);
			$this->db->or_like('posts.p_post', $search_param);
			$this->db->or_like('employees.emp_login', $search_param);
			$this->db->or_like('employees.emp_first_name', $search_param);
			$this->db->or_like('employees.emp_last_name', $search_param);
		}
		$this->db->join('divisions', 'divisions.division_id = employees.emp_divi_id');
		$this->db->join('posts', 'posts.post_id = employees.emp_post_id');
		$this->db->order_by('employees.emp_login');
		$this->db->limit($limit, $start);
		return $this->db->get('employees');
	}
	
	function get_emp_data($id)
	{
		$this->db->join('divisions', 'divisions.division_id = employees.emp_divi_id');
		$this->db->join('posts', 'posts.post_id = employees.emp_post_id');
		$this->db->order_by('employees.emp_login');
		$this->db->where('emp_id', $id);
		return $this->db->get('employees');
	}
	
	function get_posts()
	{
		return $this->db->get('posts');
	}
	
	function get_divisions()
	{
		return $this->db->get('divisions');
	}
	

	function insert($data)
	{
		$this->db->insert('employees', $data);
	}
	
	function update($id, $data)
	{	
		$this->db->where('emp_id', $id);
		$this->db->update('employees', $data);
	}
	
	function delete($id)
	{
		$this->drop_fingers($id);
		$this->db->where('emp_id', $id);
		$this->db->delete('employees');
	}
	
	// Надо бы удалять инфу об отпечатках, но влом реализовывать, буду удалять только пальцы
	/*function drop_dactil($id)
	{
		$this->db->where('dacti_id', $id);
        $this->db->delete('dactilos');
	}*/
	
	function drop_fingers($id)
	{
		$this->db->where('fing_emp_id', $id);
        $this->db->delete('fingers');
	}
	
	function drop_finger($id)
	{
		$this->db->where('fing_id', $id);
        $this->db->delete('fingers');
	}
	
	function get_user_finger($id, $start, $limit)
	{
		$this->db->join('employees', 'employees.emp_id = fingers.fing_emp_id');
		$this->db->join('dactilos', 'dactilos.dacti_id = fingers.fing_dactil');
		$this->db->order_by('fingers.fing_id');
		$this->db->limit($limit, $start);
		$this->db->where('fing_emp_id', $id);
		return $this->db->get('fingers');
	}
	
	function getAllLogins($id)
	{
		// return $this->db->get('logins');
		return $this->db->get_where('logins', array('l_u_id' => $id));
	}
	
	function getAllLogons($id)
	{
		// return $this->db->get('logons');
		return $this->db->get_where('logons', array('l_u_id' => $id));
	}
}

?>