import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import { PatientInfo } from './PatientInfo';
import '@testing-library/jest-dom';

describe('PatientInfo Component', () => {
    const mockOnGetVisits = jest.fn();
    const patientId = '123';
    const patientName = 'John Doe';
    const patientAge = 30;

    beforeEach(() => {
        render(<PatientInfo id={patientId} name={patientName} age={patientAge} onGetVisits={mockOnGetVisits} />);
    });

    
    it('should display the patient name and age', () => {
        expect(screen.getByText(`${patientName} - ${patientAge} years old`)).toBeInTheDocument();
    });

    it('should call onGetVisits with the patientId when the button is clicked', () => {
        fireEvent.click(screen.getByText('Get Visits'));
        expect(mockOnGetVisits).toHaveBeenCalledWith(patientId);
    });
});