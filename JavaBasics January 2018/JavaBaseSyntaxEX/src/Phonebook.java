import java.util.HashMap;
import java.util.Scanner;

public class Phonebook {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        HashMap<String, String> phonebook = new HashMap<String, String>();

        String input = scanner.nextLine();

        while (input.equals("END") == false) {
            String[] arr = input.split(" ");

            String command = arr[0];
            String name = arr[1];

            switch (command) {
                case "A":
                    String phone = arr[2];

                    if (phonebook.containsKey(name) == false) {
                        phonebook.put(name, phone);
                    } else {
                        phonebook.put(name, phone);
                    }
                    break;
                case "S":
                    if (phonebook.containsKey(name) == false) {
                        System.out.printf("Contact %s does not exist.%n", name);
                    } else {
                        System.out.println(name + " -> " + phonebook.get(name));
                    }
                    break;
            }
            input = scanner.nextLine();
        }
    }
}
