import React, { useState } from "react";
import "../../styles.css";

const AddPersonModal = ({ isOpen, onClose, onSubmit }) => {
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

  return (
    isOpen && (
      <div className="modal-content">
        <h3>Add New Person</h3>
        <form onSubmit={onSubmit}>
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
