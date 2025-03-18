// Define the Contact interface
interface Contact {
    id: number;
    name: string;
    email: string;
    phone: string;
}

// Implement the ContactManager class
class ContactManager {
    private contacts: Contact[] = [];

    // Add a new contact
    addContact(contact: Contact): void {
        this.contacts.push(contact);
        console.log(`Contact added: ${contact.name}`);
    }

    // View all contacts
    viewContacts(): Contact[] {
        return this.contacts;
    }

    // Modify an existing contact
    modifyContact(id: number, updatedContact: Partial<Contact>): void {
        const contact = this.contacts.find(c => c.id === id);
        if (!contact) {
            console.log(`Error: Contact with ID ${id} not found.`);
            return;
        }
        Object.assign(contact, updatedContact);
        console.log(`Contact updated: ${contact.name}`);
    }

    // Delete a contact
    deleteContact(id: number): void {
        const index = this.contacts.findIndex(c => c.id === id);
        if (index === -1) {
            console.log(`Error: Contact with ID ${id} not found.`);
            return;
        }
        const deletedContact = this.contacts.splice(index, 1);
        console.log(`Contact deleted: ${deletedContact[0].name}`);
    }
}

// Testing the ContactManager functionality
const contactManager = new ContactManager();

// Adding contacts
contactManager.addContact({ id: 1, name: "John Doe", email: "john@example.com", phone: "123-456-7890" });
contactManager.addContact({ id: 2, name: "Jane Smith", email: "jane@example.com", phone: "987-654-3210" });

// Viewing contacts
console.log("Contacts:", contactManager.viewContacts());

// Modifying a contact
contactManager.modifyContact(1, { phone: "111-222-3333" });

// Deleting a contact
contactManager.deleteContact(2);

// Viewing contacts after modifications
console.log("Updated Contacts:", contactManager.viewContacts());
