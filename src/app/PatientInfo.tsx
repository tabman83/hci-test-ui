// PatientInfo.tsx
import React from 'react';
import { Button } from 'react-bootstrap';

interface PatientInfoProps {
    id: string;
    name: string;
    age: number;
    onGetVisits: (patientId: string) => void;
}

export const PatientInfo: React.FC<PatientInfoProps> = ({ id, name, age, onGetVisits }) => {
    return (
        <div>
            <h2>{name} - {age} years old</h2>
            <Button onClick={() => onGetVisits(id)}>Get Visits</Button>
        </div>
    );
};