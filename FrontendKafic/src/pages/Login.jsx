import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import useAuth from '../hooks/useAuth';

export default function Login() {
  const { login } = useAuth();

  function handleSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);
    login({
      email: podaci.get('email'),
      password: podaci.get('lozinka'),
    });
  }

  return (
    <div className='loginDiv'>
      <div className='loginDiv2'>
        <Container className='mt-4'>
            <h1>Login</h1>
            <p>Please enter your email and password!</p>
            <p>
                E-mail: damirbukvasevic@gmail.com
            </p>
            <p>
                Password: DambaV1
            </p>
          <Form onSubmit={handleSubmit}>
              <Form.Group className='mb-3' controlId='email'>
              <Form.Label>E-mail</Form.Label>
              <Form.Control
                  className='emailControl'
                  type='text'
                  name='email'
                  placeholder='damirbukvasevic@gmail.com'
                  maxLength={255}
                  required
              />
              </Form.Group>
              <Form.Group className='mb-3' controlId='lozinka'>
              <Form.Label>Password</Form.Label>
              <Form.Control
                  className='lozinkaControl'
                  type='password'
                  name='lozinka'
                  placeholder='*****'
                  required />
              </Form.Group>
              <Button variant='primary' className='gumbLogIn' type='submit'>
              Sign in
              </Button>
          </Form>
        </Container>
      </div>
    </div>
  );
}