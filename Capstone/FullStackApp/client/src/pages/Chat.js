// import { useState, useEffect, useRef } from 'react';
// import { useDispatch, useSelector } from 'react-redux';
// import { addMessage } from '../store/chatSlice';
// import 'bootstrap/dist/css/bootstrap.min.css';

// const Chat = () => {
//   const [text, setText] = useState('');
//   const messages = useSelector((state) => state.chat.messages);
//   const dispatch = useDispatch();
//   const chatEndRef = useRef(null);

//   useEffect(() => {
//     // Auto-scroll to latest message
//     chatEndRef.current?.scrollIntoView({ behavior: 'smooth' });
//   }, [messages]);

//   const handleSend = () => {
//     if (text.trim()) {
//       const message = { sender: 'You', text };
//       dispatch(addMessage(message));
//       setText('');
//     }
//   };

//   return (
//     <div className="d-flex flex-column vh-100 bg-light">
//       {/* Chat Header */}
//       <div className="bg-primary text-white py-3 text-center fw-bold">
//         Chat Room
//       </div>

//       {/* Chat Messages */}
//       <div className="flex-grow-1 overflow-auto p-3" style={{ maxHeight: "75vh" }}>
//         {messages.length === 0 ? (
//           <p className="text-muted text-center mt-5">Start a conversation...</p>
//         ) : (
//           messages.map((msg, index) => (
//             <div 
//               key={index} 
//               className={`d-flex mb-2 ${msg.sender === 'You' ? 'justify-content-end' : 'justify-content-start'}`}
//             >
//               <div className={`p-2 rounded-3 ${msg.sender === 'You' ? 'bg-primary text-white' : 'bg-secondary text-white'}`} 
//                    style={{ maxWidth: "75%" }}>
//                 <small className="d-block fw-bold">{msg.sender}</small>
//                 {msg.text}
//               </div>
//             </div>
//           ))
//         )}
//         <div ref={chatEndRef} /> {/* Auto-scroll reference */}
//       </div>

//       {/* Chat Input */}
//       <div className="p-3 bg-white border-top d-flex">
//         <input 
//           type="text" 
//           className="form-control me-2" 
//           placeholder="Type a message..." 
//           value={text} 
//           onChange={(e) => setText(e.target.value)} 
//         />
//         <button className="btn btn-primary" onClick={handleSend}>Send</button>
//       </div>
//     </div>
//   );
// };

// export default Chat;

// import { useState, useEffect, useRef } from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';

// // Users with different background colors
// const users = [
//   { id: 1, name: "Deenathayalan", color: "#FF5733" },   // Orange
//   { id: 2, name: "Sameera", color: "#3498DB" }, // Blue
//   { id: 3, name: "Naveen", color: "#2ECC71" }, // Green
//   { id: 4, name: "Manivannan", color: "#9B59B6" }  // Purple
// ];

// const Chat = () => {
//   const [selectedUser, setSelectedUser] = useState(users[0]);
//   const [messages, setMessages] = useState({});
//   const [text, setText] = useState('');
//   const chatEndRef = useRef(null);

//   // Scroll to the bottom of chat
//   useEffect(() => {
//     chatEndRef.current?.scrollIntoView({ behavior: "smooth" });
//   }, [messages]);

//   // Handle sending messages
//   const handleSend = () => {
//     if (text.trim()) {
//       setMessages((prevMessages) => ({
//         ...prevMessages,
//         [selectedUser.id]: [
//           ...(prevMessages[selectedUser.id] || []),
//           { sender: "You", text }
//         ]
//       }));
//       setText("");
//     }
//   };

//   return (
//     <div className="d-flex vh-100">
//       {/* Sidebar */}
//       <div className="bg-dark text-white p-3" style={{ width: "250px" }}>
//         <h5 className="text-center mb-3">Users</h5>
//         <ul className="list-unstyled">
//           {users.map((user) => (
//             <li 
//               key={user.id} 
//               className={`p-2 mb-2 rounded d-flex align-items-center ${selectedUser.id === user.id ? 'border border-light' : ''}`}
//               style={{ 
//                 cursor: 'pointer', 
//                 backgroundColor: user.color,
//                 color: "white"
//               }} 
//               onClick={() => setSelectedUser(user)}
//             >
//               <div className="px-3 py-1 rounded fw-bold">
//                 {user.name}
//               </div>
//             </li>
//           ))}
//         </ul>
//       </div>

//       {/* Chat Section */}
//       <div className="d-flex flex-column flex-grow-1 bg-light">
//         {/* Chat Header */}
//         <div className="py-3 px-3 d-flex align-items-center" style={{ backgroundColor: selectedUser.color, color: "white" }}>
//           <h5 className="mb-0">{selectedUser.name}</h5>
//         </div>

//         {/* Chat Messages */}
//         <div className="flex-grow-1 overflow-auto p-3" style={{ maxHeight: "75vh" }}>
//           {messages[selectedUser.id]?.length === 0 ? (
//             <p className="text-muted text-center mt-5">Say hi to {selectedUser.name}...</p>
//           ) : (
//             messages[selectedUser.id]?.map((msg, index) => (
//               <div key={index} className={`d-flex mb-2 ${msg.sender === 'You' ? 'justify-content-end' : 'justify-content-start'}`}>
//                 <div className={`p-2 rounded-3 ${msg.sender === 'You' ? 'bg-primary text-white' : 'bg-secondary text-white'}`} style={{ maxWidth: "75%" }}>
//                   <small className="d-block fw-bold">{msg.sender}</small>
//                   {msg.text}
//                 </div>
//               </div>
//             ))
//           )}
//           <div ref={chatEndRef} />
//         </div>

//         {/* Chat Input */}
//         <div className="p-3 bg-white border-top d-flex">
//           <input 
//             type="text" 
//             className="form-control me-2" 
//             placeholder={`Message ${selectedUser.name}...`} 
//             value={text} 
//             onChange={(e) => setText(e.target.value)} 
//           />
//           <button className="btn btn-primary" onClick={handleSend}>Send</button>
//         </div>
//       </div>
//     </div>
//   );
// };

// export default Chat;


import { useState, useEffect, useRef } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from "../assets/chatapplogo.png"; 

// Users with different background colors
const users = [
  { id: 1, name: "Deenathayalan", color: "#FF5733" },   // Orange
  { id: 2, name: "Sameera", color: "#3498DB" }, // Blue
  { id: 3, name: "Naveen", color: "#2ECC71" }, // Green
  { id: 4, name: "Manivannan", color: "#9B59B6" }  // Purple
];

const Chat = () => {
  const [selectedUser, setSelectedUser] = useState(users[0]);
  const [messages, setMessages] = useState({});
  const [text, setText] = useState('');
  const chatEndRef = useRef(null);

  // Scroll to the bottom of chat
  useEffect(() => {
    chatEndRef.current?.scrollIntoView({ behavior: "smooth" });
  }, [messages]);

  // Handle sending messages
  const handleSend = () => {
    if (text.trim()) {
      setMessages((prevMessages) => ({
        ...prevMessages,
        [selectedUser.id]: [
          ...(prevMessages[selectedUser.id] || []),
          { sender: "You", text }
        ]
      }));
      setText("");
    }
  };

  return (
    <div className="d-flex vh-100">
      {/* Sidebar */}
      <div className="bg-dark text-white p-3" style={{ width: "250px" }}>
        <div className="text-center mb-3">
          <img src={logo} alt="Chat Logo" style={{ width: "80px", height: "80px", borderRadius: "50%" }} />
        </div>
        <h5 className="text-center mb-3">Users</h5>
        <ul className="list-unstyled">
          {users.map((user) => (
            <li 
              key={user.id} 
              className={`p-2 mb-2 rounded d-flex align-items-center ${selectedUser.id === user.id ? 'border border-light' : ''}`}
              style={{ 
                cursor: 'pointer', 
                backgroundColor: user.color,
                color: "white"
              }} 
              onClick={() => setSelectedUser(user)}
            >
              <div className="px-3 py-1 rounded fw-bold">
                {user.name}
              </div>
            </li>
          ))}
        </ul>
      </div>

      {/* Chat Section */}
      <div className="d-flex flex-column flex-grow-1 bg-light">
        {/* Chat Header with Logo */}
        <div className="d-flex align-items-center py-3 px-3" style={{ backgroundColor: selectedUser.color, color: "white" }}>
          <img src={logo} alt="Chat Logo" style={{ width: "40px", height: "40px", borderRadius: "50%", marginRight: "10px" }} />
          <h5 className="mb-0">{selectedUser.name}</h5>
        </div>

        {/* Chat Messages */}
        <div className="flex-grow-1 overflow-auto p-3" style={{ maxHeight: "75vh" }}>
          {messages[selectedUser.id]?.length === 0 ? (
            <p className="text-muted text-center mt-5">Say hi to {selectedUser.name}...</p>
          ) : (
            messages[selectedUser.id]?.map((msg, index) => (
              <div key={index} className={`d-flex mb-2 ${msg.sender === 'You' ? 'justify-content-end' : 'justify-content-start'}`}>
                <div className={`p-2 rounded-3 ${msg.sender === 'You' ? 'bg-primary text-white' : 'bg-secondary text-white'}`} style={{ maxWidth: "75%" }}>
                  <small className="d-block fw-bold">{msg.sender}</small>
                  {msg.text}
                </div>
              </div>
            ))
          )}
          <div ref={chatEndRef} />
        </div>

        {/* Chat Input */}
        <div className="p-3 bg-white border-top d-flex">
          <input 
            type="text" 
            className="form-control me-2" 
            placeholder={`Message ${selectedUser.name}...`} 
            value={text} 
            onChange={(e) => setText(e.target.value)} 
          />
          <button className="btn btn-primary" onClick={handleSend}>Send</button>
        </div>
      </div>
    </div>
  );
};

export default Chat;

