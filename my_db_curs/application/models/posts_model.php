<?php
class Posts_model extends CI_Model 
{	
	function get_data($start, $limit, $search_param)
	{
		if (isset($search_param))
		{
			$this->db->like('posts.p_post', $search_param);
			$this->db->or_like('posts.ismanager', $search_param);
		}

		$this->db->order_by('posts.p_post');
		$this->db->limit($limit, $start);
		return $this->db->get('posts');
	}
	
	function insert($data)
	{
		$this->db->insert('posts', $data);
	}
	
	function update($id, $data)
	{
		$this->db->where('post_id', $id);
		$this->db->update('posts', $data);
	}
	
	function delete($id)
	{
		$this->update_emp_before_delete($id);
		$this->db->where('post_id', $id);
        $this->db->delete('posts');
	}
	
	function update_emp_before_delete($post_id)
	{
		$this->db->where('emp_post_id', $post_id);
		$this->db->set('emp_post_id', 27);
		$this->db->update('employees');
	}
}

?>