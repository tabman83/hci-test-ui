// PatientInfo.test.tsx
import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import { PatientInfo } from './PatientInfo';

describe('PatientInfo Component', () => {
    const mockOnGetVisits = jest.fn();

    it('should display the patient name', () => {
        render(<PatientInfo name="John Doe" patientId="123" onGetVisits={mockOnGetVisits} />);
        expect(screen.getByText('John Doe')).toBeInTheDocument();
    });

    it('should call onGetVisits when the button is clicked', () => {
        render(<PatientInfo name="John Doe" patientId="123" onGetVisits={mockOnGetVisits} />);
        fireEvent.click(screen.getByText('Get Visits'));
        expect(mockOnGetVisits).toHaveBeenCalledWith('123');
    });
});