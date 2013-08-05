<?php
class Divisions_model extends CI_Model 
{	
	function get_data($start, $limit, $search_param)
	{
		if (isset($search_param))
			$this->db->like('divisions.d_division', $search_param);

		$this->db->order_by('divisions.d_division');
		$this->db->limit($limit, $start);
		return $this->db->get('divisions');
	}
	
	function get_count()
	{
		return $this->db->count_all('divisions');
	}
	
	function insert($data)
	{
		$this->db->insert('divisions', $data);
	}
	
	function update($id, $data)
	{
		$this->db->where('division_id', $id);
		$this->db->update('divisions', $data);
	}
	
	function delete($id)
	{
		$this->update_emp_before_delete($id);
		$this->db->where('division_id', $id);
        $this->db->delete('divisions');
	}
	
	function update_emp_before_delete($div_id)
	{
		$this->db->where('emp_divi_id', $div_id);
		$this->db->set('emp_divi_id', 4);
		$this->db->update('employees');
	}
}

?>