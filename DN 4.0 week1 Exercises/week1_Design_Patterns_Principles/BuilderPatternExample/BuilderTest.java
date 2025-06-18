class Computer {
    private String CPU;
    private String RAM;
    private String storage;
    private String GPU;
    
    private Computer(Builder builder) {
        this.CPU = builder.CPU;
        this.RAM = builder.RAM;
        this.storage = builder.storage;
        this.GPU = builder.GPU;
    }
    
    public static class Builder {
        private String CPU;
        private String RAM;
        private String storage;
        private String GPU;
        
        public Builder setCPU(String CPU) {
            this.CPU = CPU;
            return this;
        }
        
        public Builder setRAM(String RAM) {
            this.RAM = RAM;
            return this;
        }
        
        public Builder setStorage(String storage) {
            this.storage = storage;
            return this;
        }
        
        public Builder setGPU(String GPU) {
            this.GPU = GPU;
            return this;
        }
        
        public Computer build() {
            return new Computer(this);
        }
    }
    
    @Override
    public String toString() {
        return "Computer [CPU=" + CPU + ", RAM=" + RAM + ", storage=" + storage + ", GPU=" + GPU + "]";
    }
}

public class BuilderTest {
    public static void main(String[] args) {
        Computer computer = new Computer.Builder()
            .setCPU("Intel i7")
            .setRAM("16GB")
            .setStorage("1TB SSD")
            .setGPU("NVIDIA GTX 3080")
            .build();
        
        System.out.println(computer);
    }
}
