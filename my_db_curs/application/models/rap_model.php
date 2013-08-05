<?php
class Rap_model extends CI_Model 
{	
	function get_data($start, $limit, $search_param)
	{
		if (isset($search_param))
		{
			$this->db->like('rews_and_punishes.rap_type', $search_param);
			$this->db->or_like('rews_and_punishes.rap_descr', $search_param);
		}

		$this->db->order_by('rews_and_punishes.rap_type');
		$this->db->limit($limit, $start);
		return $this->db->get('rews_and_punishes');
	}
	
	function insert($data)
	{
		$this->db->insert('rews_and_punishes', $data);
	}
	
	function update($id, $data)
	{
		$this->db->where('rap_id', $id);
		$this->db->update('rews_and_punishes', $data);
	}
	
	function delete($id)
	{
		$this->db->where('rap_id', $id);
        $this->db->delete('rews_and_punishes');
	}
}

?>