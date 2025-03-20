// import { useState } from 'react';
// import { useDispatch } from 'react-redux';
// import { loginSuccess } from '../store/authSlice';
// import { login } from '../services/authService';
// import { useNavigate } from 'react-router-dom'; 

// const Login = () => {
//   const [email, setEmail] = useState('');
//   const [password, setPassword] = useState('');
//   const dispatch = useDispatch();
//   const navigate = useNavigate(); 

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     try {
//       const data = await login(email, password);
//       dispatch(loginSuccess({ user: data.user, token: data.token }));
//       localStorage.setItem('token', data.token);
//       navigate('/chat'); 
//     } catch (error) {
//       console.error('Login failed:', error);
//     }
//   };

//   return (
//     <form onSubmit={handleSubmit}>
//       <input type="email" placeholder="Email" onChange={(e) => setEmail(e.target.value)} required />
//       <input type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} required />
//       <button type="submit">Login</button>
//     </form>
//   );
// };

// export default Login;


// import { useState } from 'react';
// import { useDispatch } from 'react-redux';
// import { useNavigate } from 'react-router-dom'; 
// import { loginSuccess } from '../store/authSlice';
// import 'bootstrap/dist/css/bootstrap.min.css';

// const login = async (email, password) => {
//   return new Promise((resolve) => {
//     setTimeout(() => {
//       resolve({
//         user: { email, name: "Test User" },
//         token: "mocked-jwt-token"
//       });
//     }, 1000);
//   });
// };

// const Login = () => {
//   const [email, setEmail] = useState('');
//   const [password, setPassword] = useState('');
//   const dispatch = useDispatch();
//   const navigate = useNavigate();

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     try {
//       const data = await login(email, password);
//       dispatch(loginSuccess({ user: data.user, token: data.token }));
//       localStorage.setItem('token', data.token);
//       navigate('/chat');
//     } catch (error) {
//       console.error('Login failed:', error);
//     }
//   };

//   return (
//     <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
//       <div className="p-4 shadow-lg rounded bg-white" style={{ width: '350px' }}>
//         <h3 className="text-center mb-4">Real-Time Chat App</h3>
//         <form onSubmit={handleSubmit}>
//           <div className="mb-3">
//             <label className="form-label">Email</label>
//             <input 
//               type="email" 
//               className="form-control" 
//               placeholder="Enter email" 
//               onChange={(e) => setEmail(e.target.value)} 
//               required 
//             />
//           </div>
//           <div className="mb-3">
//             <label className="form-label">Password</label>
//             <input 
//               type="password" 
//               className="form-control" 
//               placeholder="Enter password" 
//               onChange={(e) => setPassword(e.target.value)} 
//               required 
//             />
//           </div>
//           <button className="btn btn-primary w-100" type="submit">Login</button>
//         </form>
//         <p className="text-center mt-3">
//           Don't have an account? <a href="/signup">Sign up</a>
//         </p>
//       </div>
//     </div>
//   );
// };

// export default Login;


import { useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { loginSuccess } from "../store/authSlice";
import "bootstrap/dist/css/bootstrap.min.css";
import "animate.css";

const login = async (email, password) => {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (email === "test@example.com" && password === "password") {
        resolve({
          user: { email, name: "Test User" },
          token: "mocked-jwt-token",
        });
      } else {
        reject("Invalid email or password.");
      }
    }, 1000);
  });
};

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [animateError, setAnimateError] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(""); // Reset error state
    try {
      const data = await login(email, password);
      dispatch(loginSuccess({ user: data.user, token: data.token }));
      localStorage.setItem("token", data.token);
      navigate("/chat");
    } catch (error) {
      setError(error);
      setAnimateError(true);
      setTimeout(() => setAnimateError(false), 1000); // Reset animation
    }
  };

  return (
    <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
      <div
        className={`p-4 shadow-lg rounded bg-white animate__animated ${
          animateError ? "animate__shakeX" : "animate__fadeInDown"
        }`}
        style={{ width: "350px" }}
      >
        <h3 className="text-center mb-4">Real-Time Chat App</h3>

        {error && <p className="text-danger text-center">{error}</p>}

        <form onSubmit={handleSubmit}>
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
          <button className="btn btn-primary w-100" type="submit">
            Login
          </button>
        </form>

        <p className="text-center mt-3">
          Don't have an account? <a href="/signup">Sign up</a>
        </p>
      </div>
    </div>
  );
};

export default Login;
