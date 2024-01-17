// PatientTable.tsx

import React from 'react';

interface IPatientData {
    id: string;
    name: string;
    dateOfVisit: string;
    department: string;
    doctor: string;
    // ... Add other fields as needed
}

interface IPatientTableProps {
    data: IPatientData[];
}

export const PatientTable: React.FC<IPatientTableProps> = ({ data }) => {
    if (data.length === 0) {
        return <p>No data found.</p>;
    }

    return (
        <table className="table">
            <thead className="thead-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Name</th>
                    <th scope="col">Date of Visit</th>
                    <th scope="col">Department</th>
                    <th scope="col">Doctor</th>
                    {/* ... Add other headers as needed */}
                </tr>
            </thead>
            <tbody>
                {data.map((patient) => (
                    <tr key={patient.id}>
                        <td>{patient.id}</td>
                        <td>{patient.name}</td>
                        <td>{patient.dateOfVisit}</td>
                        <td>{patient.department}</td>
                        <td>{patient.doctor}</td>
                        {/* ... Add other data fields as needed */}
                    </tr>
                ))}
            </tbody>
        </table>
    );
};