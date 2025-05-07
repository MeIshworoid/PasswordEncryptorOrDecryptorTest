# Password Encryption/Decryption Tool

A simple console application that allows you to encrypt and decrypt passwords using AES encryption.

## Features

- Encrypt passwords using AES encryption
- Decrypt previously encrypted passwords
- Secure encryption using AES algorithm
- Simple console-based interface
- Built with .NET Core 8

## Prerequisites

- .NET Core 8 SDK or later
- Windows operating system (for console application)

## Getting Started

1. Clone the repository:
```bash
git clone [your-repository-url]
```

2. Navigate to the project directory:
```bash
cd PasswordEncryptorOrDecryptor
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

## Usage

1. Launch the application
2. Choose from the following options:
   - Option 1: Encrypt a password
   - Option 2: Decrypt a password
   - Option 3: Exit the application

3. Follow the on-screen prompts to:
   - Enter the password you want to encrypt
   - Enter the encrypted password you want to decrypt

## Security Notes

- The application uses AES encryption for secure password handling
- The encryption key is hardcoded in the application
- For production use, consider implementing a more secure key management system

## Contributing

Feel free to submit issues and enhancement requests!

## License

This project is licensed under the MIT License - see the LICENSE file for details. 