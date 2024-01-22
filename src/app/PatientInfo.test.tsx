// PatientInfo.test.tsx
import React from 'react';
import { render, fireEvent, screen } from '@testing-library/react';
import {expect, jest, test} from '@jest/globals';
import '@testing-library/jest-dom';

import { PatientInfo } from './PatientInfo';

describe('PatientInfo Component', () => {
    const mockOnGetVisits = jest.fn();

    it('should display the patient name', () => {
        render(<PatientInfo name="John Doe" id="123" age={32} onGetVisits={mockOnGetVisits} />);
        expect(screen.getByText('John Doe - 32 years old')).toBeInTheDocument();
    });

    it('should call onGetVisits when the button is clicked', () => {
        render(<PatientInfo name="John Doe" id="123" age={41} onGetVisits={mockOnGetVisits} />);
        fireEvent.click(screen.getByText('Get Visits'));
        expect(mockOnGetVisits).toHaveBeenCalledWith('123');
    });
});