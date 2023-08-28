import React, { useState, useEffect } from 'react';
import AddPersonModal from './Modals/AddPersonModal';
import '../styles.css';

const EmployeeList = () => {
  const [employeeData, setEmployeeData] = useState([]);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const openModal = () => {
    setIsModalOpen(true);
  };

  useEffect(() => {
    fetch('https://localhost:7182/people')
      .then(response => response.json())
      .then(data => setEmployeeData(data))
      .catch(error => console.error('Error fetching employee data:', error));
  }, []);

  return (
    <div>
      <h2>Employee List</h2>
      <button onClick={openModal}>Add person</button>

      {isModalOpen && (
        <div className="modal-overlay">
          <div className="modal-content">
            <AddPersonModal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)} />
          </div>
        </div>
      )}

      {employeeData.length === 0 ? (
        <p>No employee data available.</p>
      ) : (
        <ul>
          {employeeData.map((employee, index) => (
            <li key={index}>
              <strong>Name:</strong> {employee.firstName} {employee.lastName}<br />
              <strong>Salary:</strong> ${employee.salary}<br />
              <strong>Department:</strong> {employee.department}
              <hr />
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default EmployeeList;
