import React, { useState } from "react";
import "../../styles.css";

const AddPersonModal = ({ isOpen, onClose, onEmployeeAdd }) => {
  console.log(isOpen);
  const [newEmployee, setNewEmployee] = useState({
    firstName: "",
    lastName: "",
    salary: "",
    department: "",
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setNewEmployee((prevEmployee) => ({
      ...prevEmployee,
      [name]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    
    try {
      const response = await fetch('https://localhost:7182/addPerson', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newEmployee),
      });

      if (response.ok) {
        const addedEmployee = await response.json();
        onEmployeeAdd(addedEmployee);
        alert('Success');
        onClose(); // Close the modal on success
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
        <h3>Add New Person</h3>
        <form onSubmit={handleSubmit}>
          <label>
            First Name:
            <input
              type="text"
              name="firstName"
              value={newEmployee.firstName}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Last Name:
            <input
              type="text"
              name="lastName"
              value={newEmployee.lastName}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Salary:
            <input
              type="number"
              name="salary"
              value={newEmployee.salary}
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
              value={newEmployee.department}
              onChange={handleInputChange}
              required
            />
          </label>
          <div className="modal-buttons">
            <button type="submit">Create</button>
            <button type="button" onClick={onClose}>
              Cancel
            </button>
          </div>
        </form>
      </div>
    )
  );
};

export default AddPersonModal;
