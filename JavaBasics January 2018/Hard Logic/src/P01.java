import java.util.Scanner;

public class P01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double age = Double.parseDouble(scanner.nextLine());
        String gender = scanner.nextLine();


        if (gender.equalsIgnoreCase("f")){
            if (age < 16){
                System.out.println("Miss");
            }else{
                System.out.println("Ms.");
            }
        }else if (gender.equalsIgnoreCase("m")){
            if (age < 16){
                System.out.println("Master");
            }else{
                System.out.println("Mr.");
            }
        }
    }
}
