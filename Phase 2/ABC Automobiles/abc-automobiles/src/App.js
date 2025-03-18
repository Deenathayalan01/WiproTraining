import logo from './logo.svg';
import './App.css';
import Menu from './menu';
import About from './about';
import Footer from './footer';

function App() {
  return (
    <div className="App">
      <div className='container'>
        <Menu></Menu>
        <About></About>
        <Footer></Footer>
      </div>
    </div>
  );
}

export default App;
