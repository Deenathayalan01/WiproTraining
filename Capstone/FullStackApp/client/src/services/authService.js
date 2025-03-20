import axios from 'axios';

const API_URL = 'http://localhost:5151/api/auth'; // Update with actual backend URL

export const login = async (email, password) => {
  const response = await axios.post(`${API_URL}/login`, { email, password });
  return response.data;
};

export const signup = async (email, password) => {
  const response = await axios.post(`${API_URL}/register`, { email, password });
  return response.data;
};

export const verifyToken = async (token) => {
  const response = await axios.get(`${API_URL}/verify`, {
    headers: { Authorization: `Bearer ${token}` },
  });
  return response.data;
};
