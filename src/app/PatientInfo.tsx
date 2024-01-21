// PatientInfo.tsx
import React from 'react';
import { Button } from 'react-bootstrap';

interface PatientInfoProps {
    name: string;
    patientId: string;
    onGetVisits: (patientId: string) => void;
}

export const PatientInfo: React.FC<PatientInfoProps> = ({ name, patientId, onGetVisits }) => {
    return (
        <div>
            <h2>{name}</h2>
            <Button onClick={() => onGetVisits(patientId)}>Get Visits</Button>
        </div>
    );
};