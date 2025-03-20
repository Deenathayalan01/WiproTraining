import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const Signup = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      console.log('User Registered:', { name, email, password });
      navigate('/register'); // Redirect to login after signup
    } catch (error) {
      console.error('Signup failed:', error);
    }
  };

  return (
    <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
      <div className="p-4 shadow-lg rounded bg-white" style={{ width: '350px' }}>
        <h3 className="text-center mb-4">Sign Up</h3>
        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label className="form-label">Full Name</label>
            <input 
              type="text" 
              className="form-control" 
              placeholder="Enter your name" 
              onChange={(e) => setName(e.target.value)} 
              required 
            />
          </div>
          <div className="mb-3">
            <label className="form-label">Email</label>
            <input 
              type="email" 
              className="form-control" 
              placeholder="Enter email" 
              onChange={(e) => setEmail(e.target.value)} 
              required 
            />
          </div>
          <div className="mb-3">
            <label className="form-label">Password</label>
            <input 
              type="password" 
              className="form-control" 
              placeholder="Enter password" 
              onChange={(e) => setPassword(e.target.value)} 
              required 
            />
          </div>
          <button className="btn btn-primary w-100" type="submit">Sign Up</button>
        </form>
        <p className="text-center mt-3">
          Already have an account? <a href="/">Login</a>
        </p>
      </div>
    </div>
  );
};

export default Signup;
