// VisitsList.tsx
import React from 'react';

interface Visit {
    consultantName: string;
    appointment: Date;
}

interface VisitsListProps {
    visits: Visit[];
}

export const VisitsList: React.FC<VisitsListProps> = ({ visits }) => {
    if (visits.length === 0) {
        return <p>No visits found.</p>;
    }

    return (
        <ul>
            {visits.map((visit, index) => (
                <li key={index}>
                    {visit.consultantName} - {visit.appointment.toLocaleString()}
                </li>
            ))}
        </ul>
    );
};