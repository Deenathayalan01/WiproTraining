import { fireEvent, render, screen } from '@testing-library/react';
import ReactTestUtils from 'react-dom/test-utils';
import App from './App';

test('check about component loaded or not', () => {
  render(<App />);
  const counter = screen.getByTestId("about-content");
  expect(counter).toBeInTheDocument();
});

test('check menu component loaded or not', () => {
  render(<App />);
  const counter = screen.getByTestId("menu-content");
  expect(counter).toBeInTheDocument();
});

test('check footer component loaded or not', () => {
  render(<App />);
  const counter = screen.getByTestId("footer-content");
  expect(counter).toBeInTheDocument();
});