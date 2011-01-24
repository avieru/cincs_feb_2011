class Project
  class << self
    def name
      @name = "nothinbutdotnetstore"
    end

    def startup_dir
      @startup_dir = File.join(%w[product nothinbutdotnetstore.web.ui])
    end

    def specs_dir
      @specs_dir = File.join(%w[artifacts specs])
    end

    def report_folder
      @report_folder = File.join(%w[artifacts specs report]) 
    end

    def spec_assemblies
      @spec_assemblies = Dir.glob(File.join('artifacts',"nothin*specs.dll"))
    end

    def startup_config
      @startup_config = "web.config"
    end

    def startup_extension
      @startup_extension = ".dll"
    end
  end
end
