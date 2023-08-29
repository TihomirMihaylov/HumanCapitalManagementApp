import React from 'react';
import '../../styles.css';

const DeletePersonModal = ({ isOpen, onClose, employee, onDelete }) => {
  const handleDelete = async () => {
    try {
      const response = await fetch('https://localhost:7182/deletePerson', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ personId: employee.id }), 
      });

      if (response.ok) {
        onDelete(employee.id);
        alert('Success: Employee deleted');
        onClose();
      } else {
        const errorData = await response.json();
        alert(`Error: ${errorData.message}`);
      }
    } catch (error) {
      alert(`Error: ${error.message}`);
    }
  };

  return (
    isOpen && (
      <div className="modal-overlay">
        <div className="modal-content">
          <h3>Confirm Deletion</h3>
          <p>Are you sure you want to delete {employee.firstName} {employee.lastName}?</p>
          <div className="modal-buttons">
            <button type="button" onClick={handleDelete}>Delete</button>
            <button type="button" onClick={onClose}>Cancel</button>
          </div>
        </div>
      </div>
    )
  );
};

export default DeletePersonModal;