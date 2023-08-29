import React, { useState, useEffect } from "react";
import AddPersonModal from "./Modals/AddPersonModal";
import EditPersonModal from "./Modals/EditPersonModal";
import DeletePersonModal from "./Modals/DeletePersonModal";
import "../styles.css";

const EmployeeList = () => {
  const [employeeData, setEmployeeData] = useState([]);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  useEffect(() => {
    fetch("https://localhost:7182/people")
      .then((response) => response.json())
      .then((data) => setEmployeeData(data))
      .catch((error) => console.error("Error fetching employee data:", error));
  }, []);

  const handleEmployeeAdd = (addedEmployee) => {
    setEmployeeData([...employeeData, addedEmployee]);
  };

  const handleEmployeeUpdate = (response) => {
    const updatedData = employeeData.map((employee) => {
      if (employee.id === response.person.id) {
        return { ...employee, ...response.person };
      }

      return employee;
    });

    setEmployeeData(updatedData);
  };

  const handleEmployeeDelete = () => {
    const updatedData = employeeData.filter(employee => employee.id !== selectedEmployee.id);
    setEmployeeData(updatedData);
  };

  const openEditModal = (employee) => {
    setSelectedEmployee(employee);
    setIsEditModalOpen(true);
  };

  const openDeleteModal = (employee) => {
    setSelectedEmployee(employee);
    setIsDeleteModalOpen(true);
  };

  return (
    <div>
      <h2>Employee List</h2>
      <button onClick={() => setIsCreateModalOpen(true)}>Add person</button>

      {isCreateModalOpen && (
        <div className="modal-overlay">
          <div className="modal-content">
            <AddPersonModal
              isOpen={isCreateModalOpen}
              onClose={() => setIsCreateModalOpen(false)}
              onEmployeeAdd={handleEmployeeAdd}
            />
          </div>
        </div>
      )}

      {employeeData.length === 0 ? (
        <p>No employee data available.</p>
      ) : (
        <ul>
          {employeeData.map((employee, index) => (
            <li key={index}>
              <strong>Name:</strong> {employee.firstName} {employee.lastName}
              <br />
              <strong>Salary:</strong> ${employee.salary}
              <br />
              <strong>Department:</strong> {employee.department}
              <div>
                <button onClick={() => openEditModal(employee)}>Edit</button>
                <button onClick={() => openDeleteModal(employee)}>Delete</button>
              </div>
              <hr />
            </li>
          ))}
        </ul>
      )}

      {isEditModalOpen && (
        <div className="modal-overlay">
          <div className="modal-content">
            <EditPersonModal
              isOpen={isEditModalOpen}
              onClose={() => setIsEditModalOpen(false)}
              employeeData={selectedEmployee}
              onEmployeeUpdate={handleEmployeeUpdate}
            />
          </div>
        </div>
      )}

      {isDeleteModalOpen && (
        <div className="modal-overlay">
          <div className="modal-content">
            <DeletePersonModal
              isOpen={isDeleteModalOpen}
              onClose={() => setIsDeleteModalOpen(false)}
              employee={selectedEmployee}
              onDelete={handleEmployeeDelete}
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default EmployeeList;
