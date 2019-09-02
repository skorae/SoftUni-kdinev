import java.util.HashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class PhonebookUpgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        TreeMap<String, String> phonebook = new TreeMap<String, String>();

        String input = scanner.nextLine();

        while (input.equals("END") == false) {
            String[] arr = input.split(" ");

            String command = arr[0];
            if (command.equals("ListAll")){
                for (String key : phonebook.keySet()) {
                    System.out.println(key + " -> " + phonebook.get(key));
                }
                input = scanner.nextLine();
                continue;
            }
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
                case "":
                    break;
            }
            input = scanner.nextLine();
        }
    }
}
