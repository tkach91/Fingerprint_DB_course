<?php
class Login_model extends CI_Model 
{	
	function get_login_data($hash)
	{
		$this->db->join('divisions', 'division_id=emp_divi_id');
		$this->db->join('posts', 'post_id=emp_post_id');
		$this->db->join('emp_hashes', 'emp_id=emp_hashes.emp_h_id');
		$this->db->where(array('hash' => $hash));
		return $this->db->get('employees');
	}
	
	function addLoginTime($id)
	{
		$this->db->insert('logins', array('l_u_id' => $id, 'l_login_day' => date('Y-m-d'), 'l_login_time'=>date('H:i:s')));
	}
	
	function addLogonTime($id)
	{
		$this->db->insert('logons', array('l_u_id' => $id, 'l_logon_day' => date('Y-m-d'), 'l_logon_time'=>date('H:i:s')));
	}
	
	function del_hash($id)
	{
		$this->db->where('emp_h_id', $id);
		$this->db->delete('emp_hashes');
	}
}

?>