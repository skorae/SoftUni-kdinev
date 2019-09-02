import java.util.Scanner;

public class VowelOrDigit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String n = scanner.nextLine();

        if (n.equals("a") || n.equals("e") || n.equals("o") || n.equals("u") || n.equals("i") || n.equals("y")){
            System.out.println("vowel");
        }else if (TryParse(n)){
            System.out.println("digit");
        }else{
            System.out.println("other");
        }
    }

    private static boolean TryParse(String n) {
        try {
            Integer.parseInt(n);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

}
