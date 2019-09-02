import java.util.Scanner;

public class P09 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String pass = scanner.nextLine();

        if (pass.contentEquals("s3cr3t!P@ssw0rd")) {
            System.out.println("Welcome");
        }else{
            System.out.println("Wrong password!");
        }
    }
}