import React, { useState, useEffect } from "react";
import "../../styles.css";

const EditPersonModal = ({ isOpen, onClose, employeeData, onEmployeeUpdate }) => {
  const [editedEmployee, setEditedEmployee] = useState({ ...employeeData });

  useEffect(() => {
    setEditedEmployee({ ...employeeData });
  }, [employeeData]);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setEditedEmployee((prevEmployee) => ({
      ...prevEmployee,
      [name]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const response = await fetch('https://localhost:7182/editPerson', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(editedEmployee),
      });

      if (response.ok) {
        const updatedEmployee = await response.json();
        onEmployeeUpdate(updatedEmployee);
        alert('Success');
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
      <div className="modal-content">
        <h3>Edit Person</h3>
        <form onSubmit={handleSubmit}>
          <label>
            First Name:
            <input
              type="text"
              name="firstName"
              value={editedEmployee.firstName}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Last Name:
            <input
              type="text"
              name="lastName"
              value={editedEmployee.lastName}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Salary:
            <input
              type="number"
              name="salary"
              value={editedEmployee.salary}
              onChange={handleInputChange}
              min="0"
              step="0.01"
              required
            />
          </label>
          <label>
            Department:
            <input
              type="text"
              name="department"
              value={editedEmployee.department}
              onChange={handleInputChange}
              required
            />
          </label>
          <div className="modal-buttons">
            <button type="submit">Update</button>
            <button type="button" onClick={onClose}>
              Cancel
            </button>
          </div>
        </form>
      </div>
    )
  );
};

export default EditPersonModal;